﻿namespace Entity.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public bool Activo { get; set; }

        public DateTime CreateAt { get; set;}
        public DateTime? UpdateAt { get; set;}
        public DateTime? DeleteAt { get; set; }

    }
}
