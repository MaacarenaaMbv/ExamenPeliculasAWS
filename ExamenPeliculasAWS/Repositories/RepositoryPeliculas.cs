using ExamenPeliculasAWS.Data;
using ExamenPeliculasAWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPeliculasAWS.Repositories
{
    public class RepositoryPeliculas
    {
        private PeliculasContext context;
        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }
        public async Task<List<Pelicula>> GetPeliculasAsync()
        {
            return await this.context.Peliculas.ToListAsync();
        }

        public async Task<List<Pelicula>> GetPeliculasActores(string actor)
        {
            return await this.context.Peliculas.
                Where(p => p.Actores.Contains(actor)).ToListAsync();
        }
    }
}
