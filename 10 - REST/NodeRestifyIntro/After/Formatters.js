'use strict';
// Load DATA2XML to convert movies to XML
var data2xml = require('data2xml');
var xmlConverter = data2xml();
var inflect = require('i')();

module.exports =  {
    // In case XML responses are requested
    'application/xml': function (req, res, body) {

        if (body instanceof Error) {
            return body.stack;
        }

        if (Buffer.isBuffer(body)) {
            return body.toString('base64');
        }

        var xml = '';
        var elementName = res.xmlElementName || 'element';
        if (body instanceof Array) {
            // Collection of elements
            var data = {};
            data[elementName] = body;
            var collectionName = inflect.pluralize(elementName);
            xml = xmlConverter(collectionName, data);
        }
        else {
            // Single element
            xml = xmlConverter(elementName, body);
        }

        // Make sure to set the content size
        res.setHeader('Content-Length', Buffer.byteLength(xml));
        return xml;
    }
};

