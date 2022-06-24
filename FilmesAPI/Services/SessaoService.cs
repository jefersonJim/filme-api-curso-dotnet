using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto? RecuperaSessaoPorId(int id)
        {
            Sessao? sessao = _context.Sessoes.FirstOrDefault(cinema => cinema.Id == id);
            if (sessao != null)
            {
                return _mapper.Map<ReadSessaoDto>(sessao);
            }
            return null;
        }
    }
}
