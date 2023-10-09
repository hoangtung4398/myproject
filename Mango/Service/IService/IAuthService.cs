using Mango.Web.Models;

namespace Mango.Web;

public interface IAuthService
{
    Task<ResponseDto> LoginAsync(L model);
    
}
