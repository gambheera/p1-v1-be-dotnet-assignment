using API.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class MockDataGenerator
    {
        public static List<FlightResponse> GenerateFlightData(string destinationAirportName)
        {

            List<FlightResponse> flights;
            if (destinationAirportName.Contains("Airport"))
            {
                flights = new List<FlightResponse>
                {
                    new FlightResponse(
                   "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2022-02-01T17:48:00+05:30"),
                   DateTimeOffset.Parse("2022-02-01T22:48:00+05:30"),
                   7702
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2021-03-02T00:23:00+05:30"),
                   DateTimeOffset.Parse("2021-03-02T04:23:00+05:30"),
                   10639
                ),    new FlightResponse(       "FRA",
                   "MUC",
                   DateTimeOffset.Parse("2021-11-02T00:19:00+05:30"),
                   DateTimeOffset.Parse("2021-11-02T07:19:00+05:30"),
                   10778
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-08-01T18:38:00+05:30"),
                   DateTimeOffset.Parse("2021-08-01T22:38:00+05:30"),
                   9660
                ),    new FlightResponse(       "FRA",
                   "MUC",
                   DateTimeOffset.Parse("2021-07-02T02:22:00+05:30"),
                   DateTimeOffset.Parse("2021-07-02T11:22:00+05:30"),
                   8711
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2022-03-02T00:07:00+05:30"),
                   DateTimeOffset.Parse("2022-03-02T15:07:00+05:30"),
                   6228
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2021-02-01T06:32:00+05:30"),
                   DateTimeOffset.Parse("2021-02-01T09:32:00+05:30"),
                   10716
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2022-08-01T10:38:00+05:30"),
                   DateTimeOffset.Parse("2022-08-01T19:38:00+05:30"),
                   3854
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-02-01T08:40:00+05:30"),
                   DateTimeOffset.Parse("2022-02-01T18:40:00+05:30"),
                   8566
                ),    new FlightResponse(       "CDG",
                   "AMS",
                   DateTimeOffset.Parse("2021-06-01T20:33:00+05:30"),
                   DateTimeOffset.Parse("2021-06-01T22:33:00+05:30"),
                   2716
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-05-01T18:27:00+05:30"),
                   DateTimeOffset.Parse("2021-05-01T22:27:00+05:30"),
                   6969
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2021-04-01T19:07:00+05:30"),
                   DateTimeOffset.Parse("2021-04-01T23:07:00+05:30"),
                   6306
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2021-04-01T20:22:00+05:30"),
                   DateTimeOffset.Parse("2021-04-02T09:22:00+05:30"),
                   5512
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-11-01T07:45:00+05:30"),
                   DateTimeOffset.Parse("2022-11-01T22:45:00+05:30"),
                   13671
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-08-01T06:33:00+05:30"),
                   DateTimeOffset.Parse("2022-08-01T12:33:00+05:30"),
                   6092
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2022-01-01T07:38:00+05:30"),
                   DateTimeOffset.Parse("2022-01-01T19:38:00+05:30"),
                   5851
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2022-11-01T13:10:00+05:30"),
                   DateTimeOffset.Parse("2022-11-02T01:10:00+05:30"),
                   8778
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2021-11-02T00:13:00+05:30"),
                   DateTimeOffset.Parse("2021-11-02T15:13:00+05:30"),
                   8639
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2021-10-01T08:35:00+05:30"),
                   DateTimeOffset.Parse("2021-10-01T23:35:00+05:30"),
                   10446
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2021-07-02T01:59:00+05:30"),
                   DateTimeOffset.Parse("2021-07-02T03:59:00+05:30"),
                   10293
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-10-01T11:21:00+05:30"),
                   DateTimeOffset.Parse("2021-10-01T23:21:00+05:30"),
                   10915
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2022-11-01T15:34:00+05:30"),
                   DateTimeOffset.Parse("2022-11-02T01:34:00+05:30"),
                   13565
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-07-01T07:19:00+05:30"),
                   DateTimeOffset.Parse("2022-07-01T18:19:00+05:30"),
                   9143
                ),    new FlightResponse(       "FRA",
                   "MUC",
                   DateTimeOffset.Parse("2022-11-01T18:06:00+05:30"),
                   DateTimeOffset.Parse("2022-11-02T02:06:00+05:30"),
                   11563
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2022-08-02T01:32:00+05:30"),
                   DateTimeOffset.Parse("2022-08-02T06:32:00+05:30"),
                   10884
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-07-01T12:42:00+05:30"),
                   DateTimeOffset.Parse("2022-07-02T03:42:00+05:30"),
                   11988
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-06-01T08:09:00+05:30"),
                   DateTimeOffset.Parse("2022-06-01T10:09:00+05:30"),
                   12585
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-06-01T17:38:00+05:30"),
                   DateTimeOffset.Parse("2021-06-02T06:38:00+05:30"),
                   2510
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-02-01T15:55:00+05:30"),
                   DateTimeOffset.Parse("2022-02-01T23:55:00+05:30"),
                   10411
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2021-09-01T10:19:00+05:30"),
                   DateTimeOffset.Parse("2021-09-01T17:19:00+05:30"),
                   12339
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2022-07-01T10:20:00+605:30"),
                   DateTimeOffset.Parse("2022-07-01T18:20:00+605:30"),
                   13349
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-05-02T04:04:00+05:30"),
                   DateTimeOffset.Parse("2022-05-02T17:04:00+05:30"),
                   10883
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2022-06-01T19:49:00+05:30"),
                   DateTimeOffset.Parse("2022-06-02T00:49:00+05:30"),
                   3783
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2022-11-01T23:23:00+05:30"),
                   DateTimeOffset.Parse("2022-11-02T00:23:00+05:30"),
                   7520
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2021-04-01T06:55:00+05:30"),
                   DateTimeOffset.Parse("2021-04-01T12:55:00+05:30"),
                   12102
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2022-03-01T09:56:00+05:30"),
                   DateTimeOffset.Parse("2022-03-01T11:56:00+05:30"),
                   5401
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-06-01T13:24:00+05:30"),
                   DateTimeOffset.Parse("2021-06-01T22:24:00+05:30"),
                   6256
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-05-02T02:20:00+05:30"),
                   DateTimeOffset.Parse("2021-05-02T11:20:00+05:30"),
                   13955
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2022-01-01T09:16:00+05:30"),
                   DateTimeOffset.Parse("2022-01-01T10:16:00+05:30"),
                   10355
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2022-02-01T19:42:00+05:30"),
                   DateTimeOffset.Parse("2022-02-02T05:42:00+05:30"),
                   10447
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2022-01-02T02:51:00+05:30"),
                   DateTimeOffset.Parse("2022-01-02T14:51:00+05:30"),
                   2849
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-03-01T13:18:00+05:30"),
                   DateTimeOffset.Parse("2022-03-02T02:18:00+05:30"),
                   7958
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2021-11-01T18:12:00+05:30"),
                   DateTimeOffset.Parse("2021-11-01T22:12:00+05:30"),
                   14246
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2021-11-01T23:58:00+05:30"),
                   DateTimeOffset.Parse("2021-11-02T11:58:00+05:30"),
                   14785
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2021-03-01T06:10:00+05:30"),
                   DateTimeOffset.Parse("2021-03-01T14:10:00+05:30"),
                   7103
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-03-02T02:13:00+05:30"),
                   DateTimeOffset.Parse("2022-03-02T10:13:00+05:30"),
                   3149
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2022-05-01T20:03:00+05:30"),
                   DateTimeOffset.Parse("2022-05-02T02:03:00+05:30"),
                   11508
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2022-11-01T18:33:00+05:30"),
                   DateTimeOffset.Parse("2022-11-02T03:33:00+05:30"),
                   13578
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-09-01T15:44:00+05:30"),
                   DateTimeOffset.Parse("2022-09-02T04:44:00+05:30"),
                   5901
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2022-11-01T23:26:00+05:30"),
                   DateTimeOffset.Parse("2022-11-02T02:26:00+05:30"),
                   12263
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-02-02T00:13:00+05:30"),
                   DateTimeOffset.Parse("2022-02-02T14:13:00+05:30"),
                   4650
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-04-01T09:43:00+05:30"),
                   DateTimeOffset.Parse("2021-04-01T20:43:00+05:30"),
                   14096
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2021-02-01T07:34:00+05:30"),
                   DateTimeOffset.Parse("2021-02-01T14:34:00+05:30"),
                   9534
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2021-06-02T01:59:00+05:30"),
                   DateTimeOffset.Parse("2021-06-02T02:59:00+05:30"),
                   10267
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2022-05-01T06:39:00+05:30"),
                   DateTimeOffset.Parse("2022-05-01T07:39:00+05:30"),
                   7989
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-11-01T22:43:00+05:30"),
                   DateTimeOffset.Parse("2022-11-02T08:43:00+05:30"),
                   10746
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2021-03-02T01:52:00+05:30"),
                   DateTimeOffset.Parse("2021-03-02T14:52:00+05:30"),
                   4951
                ),    new FlightResponse(       "CDG",
                   "AMS",
                   DateTimeOffset.Parse("2022-05-01T10:26:00+05:30"),
                   DateTimeOffset.Parse("2022-05-01T22:26:00+05:30"),
                   4043
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-06-01T12:57:00+05:30"),
                   DateTimeOffset.Parse("2021-06-01T21:57:00+05:30"),
                   10180
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-02-01T09:11:00+05:30"),
                   DateTimeOffset.Parse("2022-02-01T13:11:00+05:30"),
                   9340
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-07-01T06:37:00+05:30"),
                   DateTimeOffset.Parse("2021-07-01T08:37:00+05:30"),
                   14585
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-06-01T20:14:00+05:30"),
                   DateTimeOffset.Parse("2021-06-01T21:14:00+05:30"),
                   10760
                ),    new FlightResponse(       "FRA",
                   "MUC",
                   DateTimeOffset.Parse("2022-08-01T09:24:00+05:30"),
                   DateTimeOffset.Parse("2022-08-01T22:24:00+05:30"),
                   11112
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-02-01T19:44:00+05:30"),
                   DateTimeOffset.Parse("2021-02-02T01:44:00+05:30"),
                   14444
                ),    new FlightResponse(       "CDG",
                   "AMS",
                   DateTimeOffset.Parse("2021-01-01T10:58:00+05:30"),
                   DateTimeOffset.Parse("2021-01-02T01:58:00+05:30"),
                   13424
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2022-04-01T20:45:00+05:30"),
                   DateTimeOffset.Parse("2022-04-02T06:45:00+05:30"),
                   8584
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-05-01T19:06:00+05:30"),
                   DateTimeOffset.Parse("2022-05-02T04:06:00+05:30"),
                   13872
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-09-01T06:01:00+05:30"),
                   DateTimeOffset.Parse("2021-09-01T13:01:00+05:30"),
                   6586
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2022-10-01T19:54:00+05:30"),
                   DateTimeOffset.Parse("2022-10-02T02:54:00+05:30"),
                   4974
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-10-01T16:54:00+05:30"),
                   DateTimeOffset.Parse("2022-10-01T22:54:00+05:30"),
                   3701
                ),    new FlightResponse(       "FCO",
                   "ZRH",
                   DateTimeOffset.Parse("2021-05-01T10:39:00+05:30"),
                   DateTimeOffset.Parse("2021-05-02T01:39:00+05:30"),
                   5056
                ),    new FlightResponse(       "CDG",
                   "AMS",
                   DateTimeOffset.Parse("2022-09-01T22:59:00+05:30"),
                   DateTimeOffset.Parse("2022-09-02T10:59:00+05:30"),
                   12105
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2021-06-01T05:43:00+05:30"),
                   DateTimeOffset.Parse("2021-06-01T20:43:00+05:30"),
                   11784
                ),    new FlightResponse(       "CDG",
                   "AMS",
                   DateTimeOffset.Parse("2022-03-01T20:19:00+05:30"),
                   DateTimeOffset.Parse("2022-03-02T09:19:00+05:30"),
                   8635
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-02-01T10:35:00+05:30"),
                   DateTimeOffset.Parse("2022-02-01T14:35:00+05:30"),
                   7070
                ),    new FlightResponse(       "CDG",
                   "AMS",
                   DateTimeOffset.Parse("2022-08-02T01:33:00+05:30"),
                   DateTimeOffset.Parse("2022-08-02T11:33:00+05:30"),
                   7265
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-07-01T11:17:00+05:30"),
                   DateTimeOffset.Parse("2022-07-01T16:17:00+05:30"),
                   8290
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-10-01T20:45:00+05:30"),
                   DateTimeOffset.Parse("2022-10-02T01:45:00+05:30"),
                   7471
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-04-01T09:41:00+05:30"),
                   DateTimeOffset.Parse("2021-04-02T00:41:00+05:30"),
                   7654
                ),    new FlightResponse(       "CDG",
                   "AMS",
                   DateTimeOffset.Parse("2022-09-01T15:36:00+05:30"),
                   DateTimeOffset.Parse("2022-09-02T01:36:00+05:30"),
                   12997
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2021-08-01T14:04:00+05:30"),
                   DateTimeOffset.Parse("2021-08-01T23:04:00+05:30"),
                   11863
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-05-01T18:39:00+05:30"),
                   DateTimeOffset.Parse("2022-05-01T21:39:00+05:30"),
                   10530
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-07-02T01:11:00+05:30"),
                   DateTimeOffset.Parse("2021-07-02T10:11:00+05:30"),
                   3303
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-08-01T19:45:00+05:30"),
                   DateTimeOffset.Parse("2021-08-02T03:45:00+05:30"),
                   7370
                ),    new FlightResponse(       "DUB",
                   "IST",
                   DateTimeOffset.Parse("2021-01-01T06:10:00+05:30"),
                   DateTimeOffset.Parse("2021-01-01T15:10:00+05:30"),
                   2736
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-03-01T18:57:00+05:30"),
                   DateTimeOffset.Parse("2021-03-02T07:57:00+05:30"),
                   12932
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-07-01T20:58:00+05:30"),
                   DateTimeOffset.Parse("2022-07-02T10:58:00+05:30"),
                   11817
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-10-01T18:53:00+05:30"),
                   DateTimeOffset.Parse("2022-10-02T07:53:00+05:30"),
                   10143
                ),    new FlightResponse(       "AMS",
                   "FRA",
                   DateTimeOffset.Parse("2021-04-02T00:37:00+05:30"),
                   DateTimeOffset.Parse("2021-04-02T10:37:00+05:30"),
                   9794
                ),    new FlightResponse(       "FRA",
                   "MUC",
                   DateTimeOffset.Parse("2021-11-01T22:51:00+05:30"),
                   DateTimeOffset.Parse("2021-11-02T09:51:00+05:30"),
                   5857
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-09-01T12:51:00+05:30"),
                   DateTimeOffset.Parse("2022-09-01T15:51:00+05:30"),
                   10246
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2022-01-01T21:51:00+05:30"),
                   DateTimeOffset.Parse("2022-01-02T11:51:00+05:30"),
                   9382
                ),    new FlightResponse(       "FRA",
                   "MUC",
                   DateTimeOffset.Parse("2022-07-01T08:10:00+05:30"),
                   DateTimeOffset.Parse("2022-07-01T20:10:00+05:30"),
                   6355
                ),    new FlightResponse(       "IST",
                   "ARN",
                   DateTimeOffset.Parse("2022-08-02T02:37:00+05:30"),
                   DateTimeOffset.Parse("2022-08-02T13:37:00+05:30"),
                   6327
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2022-10-01T16:30:00+05:30"),
                   DateTimeOffset.Parse("2022-10-01T17:30:00+05:30"),
                   7225
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2021-02-02T00:34:00+05:30"),
                   DateTimeOffset.Parse("2021-02-02T13:34:00+05:30"),
                   12920
                ),    new FlightResponse(       "BCN",
                   "DUB",
                   DateTimeOffset.Parse("2022-07-01T13:47:00+05:30"),
                   DateTimeOffset.Parse("2022-07-01T21:47:00+05:30"),
                   3651
                ),    new FlightResponse(       "MUC",
                   "CPH",
                   DateTimeOffset.Parse("2022-05-01T06:21:00+05:30"),
                   DateTimeOffset.Parse("2022-05-01T07:21:00+05:30"),
                   5401
                ),    new FlightResponse(       "ARN",
                   "FCO",
                   DateTimeOffset.Parse("2022-10-01T17:37:00+05:30"),
                   DateTimeOffset.Parse("2022-10-01T20:37:00+05:30"),
                   5402
                ),    new FlightResponse(       "CPH",
                   "BCN",
                   DateTimeOffset.Parse("2021-07-02T03:00:00+05:30"),
                   DateTimeOffset.Parse("2021-07-02T15:00:00+05:30"),
                   11249)
                };
            }
            else
            {
                flights = new List<FlightResponse> { };
            }

            return flights;
        }
    }
}
