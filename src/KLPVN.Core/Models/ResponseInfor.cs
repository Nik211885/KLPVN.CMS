using System.Net;

namespace KLPVN.Core.Models;

public record ResponseInfor(HttpStatusCode StatusCode, HttpContent Data, bool IsSuccess);
