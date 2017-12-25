var module=(function(){

    var _count=0;

    var m1=function(){
        //...
    };

    var m2=function(){
        //...
    }

    return {
        m1name : m1,
        m2name : m2
    };
})();

module.m1name();
module.m2name();

//使用上面的写法，外部代码无法读取内部的_count变量。
console.info(module1._count); //undefined

//module1就是Javascript模块的基本写法。下面，再对这种写法进行加工。

