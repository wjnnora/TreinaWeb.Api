using _0_Domain;
using Repository.EF;
using Service.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Repository.EF
{
    public class AlunoRepository : RepositoryGeneric<Aluno, int>
    {
        public AlunoRepository(MyApiDbContext context) : base(context)
        {

        }
    }
}
