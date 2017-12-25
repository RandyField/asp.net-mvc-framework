//具体来说，就是模块必须采用特定的define()函数来定义。如果一个模块不依赖其他模块，那么可以直接定义在define()函数之中。

define(function(){

    var add=function(x,y){
        return x+y;
    };

    return {
        add : add
    };
});



//上面代码为一个js文件
require(['math'],function(math){

    alert(math.add(1,1));

});




//如果这个模块还依赖其他模块，
//那么define()函数的第一个参数，必须是一个数组，指明该模块的依赖性。

define(['myLib'], function(myLib){

    　　　　function foo(){
    
    　　　　　　myLib.doSomething();
    
    　　　　}
    
    　　　　return {
    
    　　　　　　foo : foo
    
    　　　　};
    
    　　});