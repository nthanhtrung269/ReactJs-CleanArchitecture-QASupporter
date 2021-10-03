﻿using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Interfaces;
using QASupporter.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace QASupporter.Application.Services
{
    public class CachingService : ICachingService
    {
        private readonly ILogger<CachingService> _logger;
        private readonly ISettingRepository _settingRepository;
        private readonly IMemoryCache _cache;
        private const string IsLoggingDatabaseCacheKey = "IsLoggingDatabaseCacheKey";
        private const string IsLoggingDatabaseSettingName = "IsLoggingDatabase";

        public CachingService(ILogger<CachingService> logger,
            ISettingRepository settingRepository,
            IMemoryCache cache)
        {
            _logger = logger;
            _settingRepository = settingRepository;
            _cache = cache;
        }

        /// <summary>
        /// Is logging database.
        /// </summary>
        /// <returns>System.Boolean.</returns>
        public async Task<bool> IsLoggingDatabaseAsync()
        {
            try
            {
                if (_cache.TryGetValue(IsLoggingDatabaseCacheKey, out bool isLoggingDatabase))
                {
                    return isLoggingDatabase;
                }

                Setting rsSetting = await _settingRepository.GetByName(IsLoggingDatabaseSettingName);
                bool result = false;

                if (rsSetting != null)
                {
                    result = bool.Parse(rsSetting.SettingValue);
                }

                _cache.Set(IsLoggingDatabaseCacheKey, result, TimeSpan.FromMinutes(5));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Call to {nameof(IsLoggingDatabaseAsync)} failed.");
                return false;
            }
        }
    }
}
