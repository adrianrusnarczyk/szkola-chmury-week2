using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HomeWorkWeek2
{
    public class Handler
    {
        public async Task<Response> BucketList(Request request)
        {
            AmazonS3Client client = new AmazonS3Client(Amazon.RegionEndpoint.EUCentral1);
            ListObjectsV2Request listRequest = new ListObjectsV2Request
            {
                BucketName = "szkola-chmury-week2-test-bucket",
            };

            ListObjectsV2Response response = await client.ListObjectsV2Async(listRequest);
            var objects = response.S3Objects.ToList().Select(x => x.Key + '(' + x.Size + ')');
 
            return new Response(objects, request);
        }
    }

    public class Response
    {
        public IEnumerable Message { get; set; }
        public Request Request { get; set; }

        public Response(IEnumerable message, Request request)
        {
            Message = message;
            Request = request;
        }
    }

    public class Request
    {
        public Request()
        {

        }
    }
}
