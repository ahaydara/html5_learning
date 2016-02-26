using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReviewApp.Util
{
    public interface ILog
    {
        void Debug(object message);
        void Error(object message);
        void Fatal(object message);
        void Info(object message);
        void Warn(object message);
    }
}
