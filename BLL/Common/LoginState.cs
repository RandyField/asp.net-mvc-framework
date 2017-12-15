using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public enum LoginState
    {
        //未登录
        NoLogin=0,

        //账号不存在
        AccountNoExist=1,

        //密码错误
        PwdError=2,

        //账号锁定
        AccountLock=3,

        //成功
        Success=4,

        //未授权
        NoAuthorize=5,
    }
}
