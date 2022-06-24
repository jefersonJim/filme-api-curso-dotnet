using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public ReadEnderecoDto AdicionarEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
        }

        public ReadEnderecoDto? RecuperaEnderecoPorId(int id)
        {
            Endereco? endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if (endereco != null)
            {
                return _mapper.Map<ReadEnderecoDto>(endereco);
            }
            return null;
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco? endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Objeto não encontrado");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            Endereco? endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Objeto não encontrado");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
