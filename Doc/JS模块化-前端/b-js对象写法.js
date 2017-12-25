var module1=new Object({
    _count:0,

    m1:function(){
        //...
    },

    m2:function(){
        //...
    }
});

//上面的函数m1()和m2(），都封装在module1对象里。使用的时候，就是调用这个对象的属性。
module1.m1();
//但是，这样的写法会暴露所有模块成员，内部状态可以被外部改写。比如，外部代码可以直接改变内部计数器的值。
module1._count = 5;