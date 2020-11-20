﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MSMQ.MsmqListener
{
    public class MessageEventArgs
    {
        private object _messageBody;

        private string name;
        private string mail;
        public object MessageBody
        {
            get { return _messageBody; }
        }

        public string Email
        {
            get { return name; }
        }

        public string UserName
        {
            get { return name; }
        }

        public MessageEventArgs(object body)
        {
            _messageBody = body;
        }
    }
}
