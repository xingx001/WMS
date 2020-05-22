﻿using Coldairarrow.Business.TD;
using Coldairarrow.Entity.TD;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.TD
{
    [Route("/TD/[controller]/[action]")]
    public class TD_MoveDetailController : BaseApiController
    {
        #region DI

        public TD_MoveDetailController(ITD_MoveDetailBusiness tD_MoveDetailBus)
        {
            _tD_MoveDetailBus = tD_MoveDetailBus;
        }

        ITD_MoveDetailBusiness _tD_MoveDetailBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<TD_MoveDetail>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tD_MoveDetailBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<TD_MoveDetail> GetTheData(IdInputDTO input)
        {
            return await _tD_MoveDetailBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(TD_MoveDetail data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _tD_MoveDetailBus.AddDataAsync(data);
            }
            else
            {
                await _tD_MoveDetailBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tD_MoveDetailBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}