$(document).ready(function () {
    // увеличить внесенную сумму в машине
    var incrementVendingMachineMoney = function (money, countMoney) {
        $.ajax({
            type: 'GET',
            url: '/Home/AddMoney',
            dataType: 'json',
            data: { money: money },
            success: function (data) {
                if (data.Error) {
                    alert(data.Error);
                } else {
                    // увеличиваем внесенную сумму в машине
                    $(".vending-machine-money").text(data.VendingMachineMoney);

                    // уменьшаем количество монет.
                    countMoney.text(data.CountMoney);
                }
            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });
    };

    // Обработчики событий, нажатия на кнопки с количеством денег пользователя
    $(".bnt-user-money-button-1").on("click", function (e) {
        incrementVendingMachineMoney(1, $(".user-money-button-1"));
    });

    $(".bnt-user-money-button-2").on("click", function (e) {
        incrementVendingMachineMoney(2, $(".user-money-button-2"));
    });

    $(".bnt-user-money-button-5").on("click", function (e) {
        incrementVendingMachineMoney(5, $(".user-money-button-5"));
    });

    $(".bnt-user-money-button-10").on("click", function (e) {
        incrementVendingMachineMoney(10, $(".user-money-button-10"));
    });
});