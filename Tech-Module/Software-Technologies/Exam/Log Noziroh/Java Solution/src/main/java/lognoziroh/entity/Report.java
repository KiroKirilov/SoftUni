package lognoziroh.entity;

import javax.persistence.*;

@Entity
@Table(name = "reports")
public class Report {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(nullable = false)
    private String message;

    @Column(nullable = false)
    private String status;

    @Column(nullable = false)
    private String origin;

    public int getId() {
        return id;
    }

    public Report setId(int id) {
        this.id = id;
        return this;
    }

    public String getMessage() {
        return message;
    }

    public Report setMessage(String message) {
        this.message = message;
        return this;
    }

    public String getStatus() {
        return status;
    }

    public Report setStatus(String status) {
        this.status = status;
        return this;
    }

    public String getOrigin() {
        return origin;
    }

    public Report setOrigin(String origin) {
        this.origin = origin;
        return this;
    }
}
