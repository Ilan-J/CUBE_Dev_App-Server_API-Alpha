USE `db_negosud`;

INSERT INTO `supplier` (
    `name`,
    `email`,
    `address`,
    `postal_code`,
    `town`)
VALUES
    ('Domaine Tariquet',        'tariquet@localhost',   'Château du Tariquet',  '32800', 'Eauze'),
    ('Domaine de Pellehaut',    'pellehaut@localhost',  'Pellehaut',            '32250', 'Montréal'),
    ('Domaine de Joÿ',          'joy@localhost',        'Lieu dit Joy, D33',    '32110', 'Panjas'),
    ('Maison Fontan',           'fontan@localhost',     'Maubet,  ',            '32800', 'Noulens'),
    ('Domaine Uby',             'uby@localhost',        'UBY',                  '32150', 'Cazaubon');

INSERT INTO `wine_family` (`name`)
VALUES
    ('Blanc'),
    ('Rosé'),
    ('Rouge');

INSERT INTO `product` (
    `name`,
    `reference`,
    `price`,
    `tva`,
    `description`,
    `wine_date`,
    `stock`,
    `min_stock`,
    `fk_supplier`,
    `fk_wine_family`)
VALUES
    (
        'Chardonnay',
        'TA06',
        24.99,
        20,
        "",
        '23-06-2020',
        57,
        15,
        1,
        1
    ),
    (
        'Rosé de pressée',
        'TA13',
        29.99,
        20,
        "",
        '08-09-2019',
        33,
        10,
        1,
        2
    ),
    (
        'Les Marcottes',
        'PE03ELV',
        14.00,
        20,
        "",
        '15-04-2018',
        69,
        20,
        2,
        3
    );

INSERT INTO client (
    `name`,
    `surname`,
    `email`,
    `password`)
VALUES
    (
        'Patrick',
        'Balkany',
        'p.balkany@localhost',
        MD5('1234')
    );