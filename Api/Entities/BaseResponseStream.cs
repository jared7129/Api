using System.IO;

namespace Api.Entities
{

    public class BaseResponseStream : BaseResponse
    {

        public virtual byte[] Buffer { get; set; }


        public virtual MemoryStream Stream => new MemoryStream(this.Buffer ?? new byte[0]);
    }
}