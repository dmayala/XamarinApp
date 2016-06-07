using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace RaysHotDogs.Core
{
	public class HotDogWebRepository
	{
		private string url = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";
		private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();

		public HotDogWebRepository()
		{
			Task.Run(() => this.LoadDataAsync(url)).Wait();
		}

		public List<HotDog> GetAllHotDogs() 
		{
			IEnumerable<HotDog> hotDogs = 
				hotDogGroups.SelectMany(hotDogGroup => hotDogGroup.HotDogs, (hotDogGroup, hotDog) => hotDog);
			return hotDogs.ToList<HotDog>();
		}

		public List<HotDogGroup> GetGroupedHotDogs() 
		{
			return hotDogGroups;
		}

		public HotDog GetHotDogById(int hotDogId) 
		{
			IEnumerable<HotDog> hotDogs = 
				hotDogGroups.SelectMany(hotDogGroup => hotDogGroup.HotDogs, (hotDogGroup, hotDog) => new {
					hotDogGroup,
					hotDog
				}).Where(_ => _.hotDog.HotDogId == hotDogId).Select(_1 => _1.hotDog);
			return hotDogs.FirstOrDefault();
		}

		private async Task LoadDataAsync(string uri)
		{
			if (hotDogGroups != null) 
			{
				string responseJsonString = null;

				using (var httpClient = new HttpClient()) 
				{
					try 
					{
						Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

						HttpResponseMessage response = await getResponse;

						responseJsonString = await response.Content.ReadAsStringAsync();
					} 
					catch (Exception ex) 
					{
						//handle any errors here, not part of the sample app
						string message = ex.Message;
					}
				}

				hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(responseJsonString);
			}
		}

		public List<HotDog> GetFavoriteHotDogs()
		{
			IEnumerable <HotDog> hotDogs = 
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs
					where hotDog.IsFavorite
				select hotDog;

			return hotDogs.ToList<HotDog> ();
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
		{
			var group =  hotDogGroups.Where (h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

			if (group != null) 
			{
				return group.HotDogs;
			}
			return null;
		}
	}
}

