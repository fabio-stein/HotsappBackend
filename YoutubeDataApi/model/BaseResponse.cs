using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeDataApi.model
{
    public class BaseResponse
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string nextPageToken { get; set; }
        public string prevPageToken { get; set; }
        public PageInfo pageInfo { get; set; }
        public BaseResult[] items { get; set; }
    }

    public class PageInfo
    {
        public int resultsPerPage { get; set; }
        public int totalResults { get; set; }
    }
}
