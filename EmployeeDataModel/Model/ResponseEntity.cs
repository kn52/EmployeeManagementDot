﻿using System.Net;

namespace EmployeeDataModel.Model
{
    public class ResponseEntity
    {
        public HttpStatusCode httpStatusCode;

        public string message;

        public object data;

        public ResponseEntity(HttpStatusCode httpStatusCode, string message, object data)
        {
            this.httpStatusCode = httpStatusCode;
            this.message = message;
            this.data = data;
        }
    }
}
