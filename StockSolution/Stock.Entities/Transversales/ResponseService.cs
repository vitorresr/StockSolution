using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Entities.Transversales
{
    public class ResponseService
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public Object ResponseData { get; set; }

        public ResponseService GetCorrectResponse(Object responseData, string message)
        {
            ResponseService respuesta = new ResponseService();
            respuesta.Code = 0;
            respuesta.Message = message;
            respuesta.ResponseData = responseData;

            return respuesta;
        }

        public ResponseService GetIncorrectResponse(int codeError, string message)
        {
            ResponseService respuesta = new ResponseService();
            respuesta.Code = codeError;
            respuesta.Message = message;

            return respuesta;
        }
    }
}
