using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Coffee.Domain.Dtos
{
    public class EventForCreationDto
    {
        [Required]
        public string DeviceId { get; set; }
    }
}
