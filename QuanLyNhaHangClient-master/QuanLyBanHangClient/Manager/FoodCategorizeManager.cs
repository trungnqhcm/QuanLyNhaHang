﻿using Newtonsoft.Json;
using QuanLyBanHangAPI.model;
using QuanLyBanHangAPI.model.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangClient.Manager {
    class FoodCategorizeManager {
        static private FoodCategorizeManager _instance = null;
        static public FoodCategorizeManager getInstance() {
            if (_instance == null) {
                _instance = new FoodCategorizeManager();
            }
            return _instance;
        }
        private string API_CONTROLLER = "/api/foodcategories";
        private Dictionary<int, FoodCategory> _foodCategorizeList;
        public Dictionary<int, FoodCategory> FoodCategorizeList { get { return _foodCategorizeList; } }
        private FoodCategorizeManager() {
            _foodCategorizeList = new Dictionary<int, FoodCategory>();
        }
        #region Network

        public async Task getAllFoodCategorizeFromServerAndUpdate(
                    Action<NetworkResponse> cbSuccessSent = null,
                    Action<string> cbError = null
            ) {
            Action<NetworkResponse> newCBSuccessSent = delegate (NetworkResponse networkResponse) {
                if (networkResponse.Successful) {
                    _foodCategorizeList.Clear();
                    List<FoodCategory> foodCategorizeListFromSV = JsonConvert.DeserializeObject<List<FoodCategory>>(networkResponse.Data.ToString());
                    foodCategorizeListFromSV.ForEach(delegate (FoodCategory foodCategorize) {
                        _foodCategorizeList.Add(foodCategorize.FoodCategoryId, foodCategorize);
                    });
                }
                cbSuccessSent?.Invoke(networkResponse);
            };
            await RequestManager.getInstance().getAsync(
                API_CONTROLLER,
                newCBSuccessSent,
                cbError
                );
        }
        public async Task createFoodCategorizeFromServerAndUpdate(
                    string name,
                    Action<NetworkResponse> cbSuccessSent = null,
                    Action<string> cbError = null
            ) {
            Action<NetworkResponse> newCBSuccessSent = delegate (NetworkResponse networkResponse) {
                if (networkResponse.Successful) {
                    FoodCategory foodCategorizeCreated = JsonConvert.DeserializeObject<FoodCategory>(networkResponse.Data.ToString());
                    _foodCategorizeList[foodCategorizeCreated.FoodCategoryId] = foodCategorizeCreated;
                }
                cbSuccessSent?.Invoke(networkResponse);
            };
            KeyValuePair<string, string>[] keys = new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("Name", name)
            };
            await RequestManager.getInstance().postAsync(
                API_CONTROLLER,
                keys,
                newCBSuccessSent,
                cbError
                );
        }
        public async Task updateFoodCategorizeFromServerAndUpdate(
                    int foodCategorizeId,
                    string name,
                    Action<NetworkResponse> cbSuccessSent = null,
                    Action<string> cbError = null
            ) {
            Action<NetworkResponse> newCBSuccessSent = delegate (NetworkResponse networkResponse) {
                if (networkResponse.Successful) {
                    FoodCategory foodCategorizeCreated = JsonConvert.DeserializeObject<FoodCategory>(networkResponse.Data.ToString());
                    _foodCategorizeList[foodCategorizeCreated.FoodCategoryId] = foodCategorizeCreated;
                }
                cbSuccessSent?.Invoke(networkResponse);
            };
            KeyValuePair<string, string>[] keys = new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("Name", name)
            };
            await RequestManager.getInstance().putAsync(
                API_CONTROLLER + "/" + foodCategorizeId,
                keys,
                newCBSuccessSent,
                cbError
                );
        }
        public async Task deleteFoodCategorizeFromServerAndUpdate(
                    int id,
                    Action<NetworkResponse> cbSuccessSent = null,
                    Action<string> cbError = null
            ) {
            Action<NetworkResponse> newCBSuccessSent = delegate (NetworkResponse networkResponse) {
                if (networkResponse.Successful) {
                    _foodCategorizeList.Remove(id);
                }
                cbSuccessSent?.Invoke(networkResponse);
            };
            await RequestManager.getInstance().deleteAsync(
                API_CONTROLLER + "/" + id,
                newCBSuccessSent,
                cbError
                );
        }
        #endregion
    }
}
