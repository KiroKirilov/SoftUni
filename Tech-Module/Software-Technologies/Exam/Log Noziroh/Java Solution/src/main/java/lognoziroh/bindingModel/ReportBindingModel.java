package lognoziroh.bindingModel;

public class ReportBindingModel {
    private int id;

    private String message;

    private String status;

    private String origin;

    public int getId() {
        return id;
    }

    public ReportBindingModel setId(int id) {
        this.id = id;
        return this;
    }

    public String getMessage() {
        return message;
    }

    public ReportBindingModel setMessage(String message) {
        this.message = message;
        return this;
    }

    public String getStatus() {
        return status;
    }

    public ReportBindingModel setStatus(String status) {
        this.status = status;
        return this;
    }

    public String getOrigin() {
        return origin;
    }

    public ReportBindingModel setOrigin(String origin) {
        this.origin = origin;
        return this;
    }
}
