using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;


public class FilterActorsAge : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {   
        var age = DateTime.Parse(context.HttpContext.Request.Form["DataOfBirth"]).Year;
        if (DateTime.Now.Year - age < 7 || DateTime.Now.Year - age > 99)
        {   
            context.Result = new BadRequestResult();
        }
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}
