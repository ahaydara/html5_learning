using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatServer.Controllers
{
    public class ChatMessage
    {
        public int Index { get; set; }
        public string ChatName { get; set; }
        public string Message { get; set; }
    }

    public class AccessControlAllowOriginAttribute : ActionFilterAttribute
    {
        public string Origin { get; set; }
        
        public AccessControlAllowOriginAttribute()
        {
            Origin = "*";
        }
        
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", Origin);
        }
    }

    //[AccessControlAllowOrigin(Origin="http://localhost:7777")]
    public class ChatController : Controller
    {
        static List<ChatMessage> _messages = new List<ChatMessage>();

        [HttpPost]
        public ActionResult Say(string chatName, string message)
        {
            var msg = new ChatMessage { ChatName = chatName, Message = message, Index = _messages.Count };
            _messages.Add(msg);
            return Json(msg);
        }
        
        [HttpPost]
        public ActionResult GetSince(int lastIndex)
        {
            var list = _messages.Where(x => x.Index > lastIndex).ToArray();
            return Json(list);
        }
    }
}
