﻿namespace ApiModelo.Application.DTOs
{
    public class ClienteDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }       
        public string Sobrenome { get; set; }     
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
