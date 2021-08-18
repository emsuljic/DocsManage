using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    public class DocsController : BaseApiController
    {
        private readonly IDocumentsRepository _documentsRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DocsController(DataContext context, IDocumentsRepository documentsRepository, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _documentsRepository = documentsRepository;

        }

        [HttpPost("addDocument")]
        public async Task<ActionResult<DocumentsDto>> AddDocument(DocumentsDto documentsDto)
        {
            //if (await DocumentExists(documentsDto.NaslovDokumenta)) return BadRequest("Dokument sa unesenim naslovom već postoji!");

            AppUser appUser = await _context.Users.Where(m => m.Id == documentsDto.AppUserId).FirstOrDefaultAsync();

            Documents document = new Documents
            {
                NaslovDokumenta = documentsDto.NaslovDokumenta,
                VrstaDokumenta = documentsDto.VrstaDokumenta,
                TipDokumenta = documentsDto.TipDokumenta,
                DatumDokumenta = Convert.ToDateTime(documentsDto.DatumDokumenta),
                DatumUnosaDokumenta = Convert.ToDateTime(documentsDto.DatumUnosaDokumenta),
                FizickoLice = documentsDto.FizickoLice,
                Napomena = documentsDto.Napomena,
                Vrijednost = documentsDto.Vrijednost,
                Posiljaoc = documentsDto.Posiljaoc,
                Primaoc = documentsDto.Primaoc,
                AppUserId = documentsDto.AppUserId
            };

            _context.Docs.Add(document);
            await _context.SaveChangesAsync();

            return new DocumentsDto
            {
                NaslovDokumenta = document.NaslovDokumenta,
                VrstaDokumenta = document.VrstaDokumenta,
                TipDokumenta = document.TipDokumenta,
                DatumDokumenta = document.DatumDokumenta,
                DatumUnosaDokumenta = document.DatumUnosaDokumenta,
                FizickoLice = document.FizickoLice,
                Napomena = document.Napomena,
                Vrijednost = document.Vrijednost,
                Posiljaoc = document.Posiljaoc,
                Primaoc = document.Primaoc,
                AppUserId = document.AppUserId
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentsDto>>> GetDocuments()
        {
            var docs = await _documentsRepository.GetDocsAsync();
            return Ok(docs);

        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<Documents>> GetDocument(int Id)
        {
            return await _documentsRepository.GetDocByIdAsync(Id);

        }

        // private async Task<bool> DocumentExists(string naslov)
        // {
        //     return await _context.Docs.AnyAsync(x => x.NaslovDokumenta == naslov.ToLower());
        // }
    }
}