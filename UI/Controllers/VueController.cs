﻿using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Controllers
{
    public class VueController : ApiController
    {

        public string Get()
        {
            List<GoodsModel> list = new List<GoodsModel> {
                            new GoodsModel{price="69.90",title="德芙",img="http://m.360buyimg.com/babel/s211x211_jfs/t3688/270/776223567/128582/fa074fb3/58170f6dN6b9a12bf.jpg"},
                            new GoodsModel{price="63.00",title="费列罗",img="http://m.360buyimg.com/babel/s211x211_jfs/t613/100/1264998035/221234/1a29d51f/54c34525Nb4f6581c.jpg"},
                            new GoodsModel{price="29.90",title="大米",img="http://m.360buyimg.com/babel/s211x211_jfs/t1258/40/17387560/108696/aced445f/54e011deN3ae867ae.jpg"},
                            new GoodsModel{price="54.90",title="安慕希",img="http://m.360buyimg.com/babel/s211x211_jfs/t2734/15/680373407/215934/3abaa748/572057daNc09b5da7.jpg"},
                            new GoodsModel{price="58.90",title="金典",img="http://m.360buyimg.com/babel/s211x211_jfs/t2482/145/1424008556/91991/d62f5454/569f47a2N3f763060.jpg"},
                            new GoodsModel{price="60.00",title="味可滋",img="http://m.360buyimg.com/babel/s211x211_jfs/t2368/3/874563950/70786/7b5e8edd/563074c8N4d535db4.jpg"},
                            new GoodsModel{price="248.00",title="泸州老窖",img="http://m.360buyimg.com/babel/s211x211_jfs/t283/166/1424018055/189580/7c0792b7/543b4958N05fa2feb.jpg"},
                            new GoodsModel{price="328.80",title="剑南春",img="http://m.360buyimg.com/babel/s350x350_g15/M05/1A/0A/rBEhWlNeLAwIAAAAAAHyok3PZY0AAMl8gO8My0AAfK6307.jpg"},
                            new GoodsModel{price="49.00",title="蓝莓",img="http://m.360buyimg.com/babel/s211x211_jfs/t2332/148/2952098628/94387/e64654e2/56f8d76aNb088c2ab.jpg"},
                            new GoodsModel{price="68.00",title="芒果",img="http://m.360buyimg.com/n0/jfs/t3709/334/1378702984/206759/5c100ab5/58253588Naaa05c5c.jpg!q70.jpg"}
                              };

            GoodsList GoodsList = new GoodsList();
            GoodsList.goods = list;

            return JsonConvert.SerializeObject(GoodsList);
        }
    }
}
