
//如果一个模块很大，必须分成几个部分，

//或者一个模块需要继承另一个模块，

//这时就有必要采用"放大模式"（augmentation）。

var module1=(function(mod){
    
    mod.m3=function(){
        //..
    }

    return mod;
})(module1);

//上面的代码为module1模块添加了一个新方法m3()，然后返回新的module1模块。

//一开始没反应过来，函数立即执行

var module2={};

function abc(mod){
    mod.m3=function(){
        //..
    }

    return mod;
}

abc(module2);