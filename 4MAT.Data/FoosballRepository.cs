using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _4MAT.Data
{
    public class 
        FoosballRepository
    {
        private readonly DataContext _context;

        public FoosballRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Game>> RecentGames(DateTime since)
        {
            return await 
                _context.Games
                .Include(x => x.RedPlayer)
                .Include(x => x.BluePlayer)
                .Where(x => x.KickOff > since.ToUniversalTime())
                .ToListAsync();
        }

        public void AddGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
