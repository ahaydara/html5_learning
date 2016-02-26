function DisplayObject() {
    this.name = 'thing';
}

DisplayObject.prototype.clicked = function() {
    alert('You clicked on the ' + this.name + '!');
};

function Rect(data) {
    this.name = 'rectangle';
    this.x = +data.x;
    this.y = +data.y;
    this.w = +data.width;
    this.h = +data.height;
    this.fillStyle = data.fillStyle;
    this.strokeStyle = data.strokeStyle;

    this.draw = function(ctx) {
        helpers.rect(ctx, this);
    };

    this.contains = function(x, y) {
        return x >= this.x && x < this.x + this.w &&
               y >= this.y && y < this.y + this.h;
    };
}

Rect.prototype = new DisplayObject();

function Circle(data) {
    this.x = +data.x;
    this.y = +data.y;
    this.radius = +data.radius;
    this.fillStyle = data.fillStyle;
    this.strokeStyle = data.strokeStyle;
}

Circle.prototype = new DisplayObject();

Circle.prototype.name = 'circle';

Circle.prototype.draw = function(ctx) {
    helpers.circle(ctx, this);
};

Circle.prototype.contains = function(x, y) {
    var dx = this.x + this.radius - x;
    var dy = this.y + this.radius - y;
    return dx * dx + dy * dy <= this.radius * this.radius;
};

function Logo(data) {
    this.x = +data.x;
    this.y = +data.y;

    this.draw = function(ctx) {
        helpers.logo(ctx, this);
    }
}