﻿using RediSearchCore.Core.Entities;
using RediSearchCore.Core.Interfaces;
using RediSearchCore.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RediSearchCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        //[HttpGet("{value}")]
        [HttpGet]
        [Route("Search")]
        public ActionResult<IEnumerable<Airports>> Search(string value)
        {
            try
            {
                return Ok(new Notification
                {
                    Success = true,
                    Data = _airportService.Search(value)
            });
                
            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("CreateIndex")]
        public ActionResult<bool> CreateIndex()
        {
            try
            {
                return Ok(new Notification
                {
                    Success = true,
                    Data = _airportService.CreateIndex()
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("DropIndex")]
        public ActionResult<bool> DropIndex()
        {
            try
            {
                return Ok(new Notification
                {
                    Success = true,
                    Data = _airportService.DropIndex()
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("PushSampleData")]
        public ActionResult<bool> PushSampleData()
        {
            try
            {
                _airportService.PushSampleData();

                return Ok(new Notification
                {
                    Success = true
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<IEnumerable<Airports>>> GetAsync(string key)
        {
            try
            {
                return Ok(new Notification
                {
                    Success = true,
                    Data = await _airportService.GetAsync(key)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAsync(string docId, Dictionary<string, dynamic> docDic)
        {
            try
            {
                return Ok(new Notification
                {
                    Success = true,
                    Data = await _airportService.UpdateAsync(docId, docDic)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddAsync(string docId, Dictionary<string, dynamic> docDic)
        {
            try
            {
                return Ok(new Notification
                {
                    Success = true,
                    Data = await _airportService.AddAsync(docId, docDic)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult<bool>> DeleteAsync(string key)
        {
            try
            {
                return Ok(new Notification
                {
                    Success = true,
                    Data = await _airportService.DeleteAsync(key)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Notification
                {
                    Success = false,
                    Errors = ex.Message
                });
            }
        }
    }
}