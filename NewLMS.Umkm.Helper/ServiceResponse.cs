﻿using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Helper
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
        }
        private ServiceResponse(int statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        private ServiceResponse(Exception ex)
        {
            Errors = new List<string> { ex.Message.ToString() };
        }

        private ServiceResponse(int statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public bool Success { set; get; } = true;

        public T Data { get; set; }

        public int StatusCode { get; set; } = 200;
        public List<string> Errors { get; set; } = new List<string>();
        public string Message { get; set; }
        public static ServiceResponse<T> ReturnException(Exception ex)
        {
            return new ServiceResponse<T>(ex){
                Success = false
            };
        }

        public static ServiceResponse<T> ReturnFailed(int statusCode, List<string> errors)
        {
            return new ServiceResponse<T>(statusCode, errors)
            {
                Success = false
            };
        }

        public static ServiceResponse<T> ReturnFailed(int statusCode, string errorMessage)
        {
            var response = new ServiceResponse<T>(statusCode, new List<string> { errorMessage })
            {
                Success = false
            };
            return response;
        }

        public static ServiceResponse<T> ReturnSuccess()
        {
            return new ServiceResponse<T>(200, null);
        }

        public static ServiceResponse<T> ReturnResultWith200(T data)
        {
            return new ServiceResponse<T>(200, data);
        }

        public static ServiceResponse<T> ReturnResultWith201(T data)
        {
            return new ServiceResponse<T>(201, data);
        }

        public static ServiceResponse<T> ReturnResultWith204()
        {
            return new ServiceResponse<T>(204, null);
        }

        public static ServiceResponse<T> Return500()
        {
            return new ServiceResponse<T>(500, new List<string> { "An unexpected fault happened. Try again later." });
        }

        public static ServiceResponse<T> Return409(string message)
        {
            return new ServiceResponse<T>(409, new List<string> { message });
        }
        public static ServiceResponse<T> Return422(string message)
        {
            return new ServiceResponse<T>(422, new List<string> { message });
        }

        public static ServiceResponse<T> Return404()
        {
            return new ServiceResponse<T>(404, new List<string> { "Not Found" });
        }

        public static ServiceResponse<T> Return404(string message)
        {
            return new ServiceResponse<T>(404, new List<string> { message });
        }
    }

}
