using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Carepatron.Controllers;

[Route("api/[controller]", Name = "BaseApiRoute_[controller]")]
public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //
        //                       _oo0oo_
        //                      o8888888o
        //                      88" . "88
        //                      (| -_- |)
        //                      0\  =  /0
        //                    ___/`---'\___
        //                  .' \\|     |// '.
        //                 / \\|||  :  |||// \
        //                / _||||| -:- |||||- \
        //               |   | \\\  -  /// |   |
        //               | \_|  ''\---/''  |_/ |
        //               \  .-\__  '-'  ___/-. /
        //             ___'. .'  /--.--\  `. .'___
        //          ."" '<  `.___\_<|>_/___.' >' "".
        //         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
        //         \  \ `_.   \_ __\ /__ _/   .-` /  /
        //     =====`-.____`.___ \_____/___.-`___.-'=====
        //                       `=---='
        //
        //
        //     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //
        //     The golden buddha bless your code to be bug free.
        //
    }
}