function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        // hasClass('d-none') -> Statistics are hidden
        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7240/api/statistics', function (data) {
                $('#total_cars').text(data.totalListedCars + " Cars Listed");
                $('#total_bought').text(data.totalBought + " Already Bought");

                $('#statistics_box').removeClass('d-none');

                $('#statistics_btn').text('Hide Statistics');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            });
        } else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Show Statistics');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
    });
}