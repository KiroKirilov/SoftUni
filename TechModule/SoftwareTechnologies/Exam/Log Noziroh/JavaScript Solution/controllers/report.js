const Report = require('../models/Report');

module.exports = {
    index: (req, res) => {
        Report.find().then(reports => {
            res.render('report/index', {'reports': reports});
        });
    },
    createGet: (req, res) => {
        res.render('report/create');
    },
    createPost: (req, res) => {
        let report = req.body;
        Report.create(report).then(report => {
            res.redirect("/");
        }).catch(err => {
            report.error = 'Cannot create report.';
            res.render('report/create', report);
        });
    },
    detailsGet: (req, res) => {
        let repId = req.params.id;
        Report.findById(repId).then(report => {
            if (report) {
                return res.render('report/details', report);
            }
            else {
                return res.redirect('/');
            }
        }).catch(err => res.redirect('/'));
    },
    deleteGet: (req, res) => {
        let repId = req.params.id;
        Report.findById(repId).then(report => {
            if (report) {
                return res.render('report/delete', report);
            }
            else {
                return res.redirect('/');
            }
        }).catch(err => res.redirect('/'));
    },

    deletePost: (req, res) => {
        let repId = req.params.id;
        Report.findByIdAndRemove(repId).then(report => {
            res.redirect('/');
        }).catch(err => res.redirect('/'))
    }


};