using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace web {
    public interface IRelatorio{
        Task Imprime(HttpContext context);
    }
}
