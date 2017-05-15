var table = $('#group-data').DataTable({
    "paging": true,
    "lengthChange": true,
    "searching": true,
    "ordering": true,
    "info": true,
    "autoWidth": true,
    "visible": true,
    "columnDefs": [{
        "targets": ['nosort', 'no-sort'],
        "orderable": false,
        'searchable': false,
    }],
    'order': [1, 'asc']
});