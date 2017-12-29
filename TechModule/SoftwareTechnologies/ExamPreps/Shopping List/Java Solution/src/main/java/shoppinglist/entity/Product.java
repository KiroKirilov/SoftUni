package shoppinglist.entity;

import javax.persistence.*;

@Entity
@Table(name = "products")
public class Product {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(nullable = false)
    private String Name;

    @Column(nullable = false)
    private Integer Priority;

    @Column(nullable = false)
    private Integer Quantity;

    @Column(nullable = false)
    private String Status;

    public int getId() {
        return id;
    }

    public Product setId(int id) {
        this.id = id;
        return this;
    }

    public String getName() {
        return Name;
    }

    public Product setName(String name) {
        Name = name;
        return this;
    }

    public Integer getPriority() {
        return Priority;
    }

    public Product setPriority(Integer priority) {
        Priority = priority;
        return this;
    }

    public Integer getQuantity() {
        return Quantity;
    }

    public Product setQuantity(Integer quantity) {
        Quantity = quantity;
        return this;
    }

    public String getStatus() {
        return Status;
    }

    public Product setStatus(String status) {
        Status = status;
        return this;
    }
}
