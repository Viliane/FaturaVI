using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FVI.Core.DomainObjects
{
    public class Email
    {
        public const int EnderecoTamanhoMaximo = 254;
        public const int EnderecoTamanhoMinino = 5;

        public string Endereco { get; private set; }

        // EF Relation
        protected Email() { }

        public Email(string endereco)
        {
            if (!Validar(endereco)) throw new DomainException("E-mail inválido");
            Endereco = endereco;
        }

        public static bool Validar(string email)
        {
            var regexEmail = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            return regexEmail.IsMatch(email);
        }
    }
}
