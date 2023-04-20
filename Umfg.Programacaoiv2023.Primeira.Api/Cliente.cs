using System;
using System.Text.Json.Serialization;

namespace Umfg.Programacaoiv2023.Primeira.Api
{
    public sealed class Cliente
    {
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        [JsonPropertyName("nome")]
        public string Nome { get; private set; }

        private Cliente() { }

        public Cliente(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }
    }
}