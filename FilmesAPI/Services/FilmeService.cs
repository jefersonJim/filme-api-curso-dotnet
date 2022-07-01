using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Add(filme);
            _context.SaveChanges(); ;
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto>? RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if(classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if(filmes == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadFilmeDto>>(filmes);
        }

        public ReadFilmeDto? RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto readFilme = _mapper.Map<ReadFilmeDto>(filme);
                return _mapper.Map<ReadFilmeDto>(filme);
            }
            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {   
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Objeto não encontrado");
            }
            _mapper.Map(filmeDto, filme);
            _context?.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            var mFilme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (mFilme == null)
            {
                return Result.Fail("Objeto não encontrado");
            }

            _context?.Remove(mFilme);
            _context?.SaveChanges();

            return Result.Ok();
        }
    }
}
