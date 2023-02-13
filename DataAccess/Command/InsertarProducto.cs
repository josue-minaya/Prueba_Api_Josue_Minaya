using MediatR;
using Prueba_Josue_Minaya.Models;
using System.Collections.Generic;
using DataAccess;
namespace Prueba_Josue_Minaya.DB.Command
{
    public class InsertarProducto
    {
        //command

        public record Command(Producto producto):IRequest<Response>;
        public class Handler:IRequestHandler<Command,Response>
        {
            public Task<Response> Handle(Command request,CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public System.Threading.Tasks.Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
        public record Response(Producto producto);
    }
}
