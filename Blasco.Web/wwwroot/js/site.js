function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7212/api/StisticsApi', function (data) {
                $('#total_products').text(data.totalProducts + " Products");
                $('#total_purchased_products').text(data.totalPurchesedProducts + " purchased Products");

                $('#statistics_box').removeClass('d-none');

                $('#statistics_btn').text('Hide statistics');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            });
        }
        else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Show statistics');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
    });
}

