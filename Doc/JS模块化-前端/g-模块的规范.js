//模块的规范


//CommonJS
//var math = require('math');


//AMD - Asynchronous Module Definition
//require([module], callback);
require(['math'], function (math) {

    　　　　math.add(2, 3);
    
    　　});


//目前，主要有两个Javascript库实现了AMD规范：require.js和curl.js