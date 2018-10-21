using System.Collections.Generic;
using ArrayCalculatorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArrayCalculatorAPI.Controllers
{
    public class ArraycalcController : ControllerBase
    {
        #region local variables
        private readonly IArrayService arrayService;
        #endregion

        #region ctor
        //array service injection
        public ArraycalcController(IArrayService arrayService)
        {
            //Service Initialisation
            this.arrayService = arrayService;
        }
        #endregion

        #region method
        //This Get method reverse the input multiple params and output as an array
        [Route("api/arraycalc/reverse")]
        [HttpGet]
        public ActionResult<IEnumerable<int>> ReverseArray()
        {
            List<int> result = new List<int>();

            //Parsing QueryString parameters as string value
            string queryString = HttpContext.Request.QueryString.ToString();

            if (!string.IsNullOrEmpty(queryString))
            {
                //Invoking array service function to reverse provided id list 
                result = arrayService.ReverseArray(queryString);
            }

            return result;
        }

        //This Get method remove one param at given position point and output as an array
        [Route("api/arraycalc/deletepart")]
        [HttpGet]
        public ActionResult<IEnumerable<int>> DeletePartArray()
        {
            List<int> result = new List<int>();

            //Parsing QueryString parameters
            string queryString = HttpContext.Request.QueryString.ToString();
            int position;

            if (!string.IsNullOrEmpty(queryString))
            {
                //Reteriving position value from query id list
                bool isParsed = int.TryParse(HttpContext.Request.Query["position"].ToString(),out position);
                position = (isParsed) ? position : 0;

                //Invoking array service function to remove an element at given point
                result = arrayService.DeletePartArray(queryString, position);
            }

            return result;
        }
        #endregion
    }
}