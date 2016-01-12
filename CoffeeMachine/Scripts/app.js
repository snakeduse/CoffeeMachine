$(document).ready(function () {

    // увеличить внесенную сумму в машине
    var incrementVendingMachineMoney = function (money) {
        $.ajax({
            type: 'GET',
            url: '/Home/Increment',
            dataType: 'json',
            data: { money: money },
            success: function (data) {
                // увеличиваем внесенную сумму в машине
                $(".vending-machine-money").text(data.VendingMachineMoney);

                // уменьшаем количество монет.
            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });
    };

    $(".bnt-user-money-button-1").on("click", function (e){
        incrementVendingMachineMoney(1);
    });

    $(".bnt-user-money-button-2").on("click", function (e){
        incrementVendingMachineMoney(2);
    });

    $(".bnt-user-money-button-5").on("click", function (e) {
        incrementVendingMachineMoney(5);
    });

    $(".bnt-user-money-button-10").on("click", function (e) {
        incrementVendingMachineMoney(10);
    });
});