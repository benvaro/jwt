using System;
using System.Collections.Generic;
using System.Text;

namespace JwtDemo.DTO.Result
{
  public   class ErrorResultDTO:ResultDTO
    {
        public List<string> Errors { get; set; } = new List<string>();
    }
}
