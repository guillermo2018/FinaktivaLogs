using EventLogsApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventLogsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLogsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventLogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventLogs>>> GetEventLogs()
        {
            return await _context.EventLogs.ToListAsync();
        }

        [HttpGet("filtrar")]
        public IActionResult FiltrarEventos(string tipoEvento, DateTime fechaInicio, DateTime fechaFin)
        {
            // Filtrar eventos por tipo de evento y rango de fechas utilizando LINQ.
            var eventosFiltrados = new List<EventLogs>();
            string formatoComparacion = "yyyy-MM-dd HH:mm:ss";
            fechaFin = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day, 23, 59, 0);
            if (fechaInicio == DateTime.MinValue && !tipoEvento.Contains("Todos"))
            {
                //Se filtra por El tipo 
                eventosFiltrados = _context.EventLogs
                .Where(e => e.EventType == tipoEvento)
                .ToList();
            }
            else if (fechaInicio == DateTime.MinValue && tipoEvento.Contains("Todos"))
            {
                //Se filtra por El tipo 
                eventosFiltrados = _context.EventLogs.ToList();
            }
            else if(tipoEvento.Contains("Todos"))
            {
                // Se filtra con dos condiciones El tipo y el rango de fechas
                eventosFiltrados = _context.EventLogs
                 .Where(e => e.EventType != tipoEvento)
                .ToList()
                .Where(e => DateTime.ParseExact(e.CreatedAt.ToString(formatoComparacion), formatoComparacion, null) >= fechaInicio && DateTime.ParseExact(e.CreatedAt.ToString(formatoComparacion), formatoComparacion, null) <= fechaFin).ToList();
            } 
            else
            {
                // Se filtra con dos condiciones El tipo y el rango de fechas
                eventosFiltrados = _context.EventLogs
                .Where(e => e.EventType == tipoEvento)
                .ToList()
                .Where(e => DateTime.ParseExact(e.CreatedAt.ToString(formatoComparacion), formatoComparacion, null) >= fechaInicio && DateTime.ParseExact(e.CreatedAt.ToString(formatoComparacion), formatoComparacion, null) <= fechaFin).ToList();
            }



            return Ok(eventosFiltrados);
        }
        // POST: api/EventLog
        [HttpPost]
        public async Task<ActionResult<EventLogs>> PostEventLog(EventLogs eventLog)
        {

            // Formatea la fecha y hora en formato de 12 horas con AM/PM
            eventLog.CreatedAt = DateTime.Now;
            _context.EventLogs.Add(eventLog);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEventLogs", new { id = eventLog.EventID }, eventLog);
        }

        // Implementa otros endpoints según tus necesidades

    }
}
