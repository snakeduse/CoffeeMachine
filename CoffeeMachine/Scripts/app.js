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

    // получить сдачу
    $(".btn-residue").on("click", function (e) {
        var money = $(".vending-machine-money").text();
        $.ajax({
            type: 'GET',
            url: '/Home/Residue',
            dataType: 'json',
            data: { money: money },
            success: function (data) {
                if (data.Error) {
                    alert(data.Error);
                } else {
                    for (var i in data.UserCoins) {
                        $(".user-money-button-" + data.UserCoins[i].Number).text(data.UserCoins[i].Count);
                    }

                    $(".vending-machine-money").text(data.VendingMachineMoney);
                }
            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });
    });

    // купить товар
    $(".btn-buy").on("click", function (e) {
        var self = this;
        var productId = $(self).attr("Id");
        var moneyInMachine = $(".vending-machine-money").text();
        var productPrice = $(self).parent("div").find(".product-price").text();

        if (productPrice > moneyInMachine) {
            alert("Недостаточно средств");
            return;
        }

        $.ajax({
            type: 'GET',
            url: '/Home/Buy',
            dataType: 'json',
            data: { productId: productId },
            success: function (data) {
                if (data.Error) {
                    alert(data.Error);
                } else {
                    // изменить количество продукта
                    $(self).parent("div").find(".product-count").text(data.Product.Count);

                    // меняем сумму VM
                    $(".vending-machine-money").text(data.VendingMachineMoney);

                    // начисляем деньги в VM
                    for (var i in data.VendingMachineCoins) {
                        $(".money-button-" + data.VendingMachineCoins[i].Number).text(data.VendingMachineCoins[i].Count);
                    }

                    alert("Спасибо!");
                }
            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });
    });
});