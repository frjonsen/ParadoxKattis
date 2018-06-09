use std;
use std::collections::BinaryHeap;
use std::cmp::Ordering;

pub struct PointAttributes {
    came_from: i32,
    cost_sum: i32

}

impl Default for PointAttributes {
    fn default() -> PointAttributes {
        PointAttributes {
            came_from: -1,
            cost_sum: std::i32::MAX
        }
    }
}

#[derive(Copy, Clone, Eq, PartialEq)]
pub struct PointQueueItem {
    priority: i32,
    indice: i32
}

impl Ord for PointQueueItem {
    fn cmp(&self, other: &PointQueueItem) -> Ordering {
        other.priority.cmp(&self.priority)
    }
}

impl PartialOrd for PointQueueItem {
    fn partial_cmp(&self, other: &PointQueueItem) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

fn get_neighbors(current_indice: i32, n_map_width: i32, n_map_height: i32) -> [i32; 4] {
    let x = current_indice % n_map_width;
    let y = current_indice / n_map_height;

    [
        if x > 0 { x - 1 + y * n_map_width } else { -1 },
        if x < (n_map_width - 1) { x + 1 + y * n_map_width as i32 } else { -1 },
        if y > 0 { x + (y - 1)  * n_map_width } else { -1 },
        if y < (n_map_height - 1) { x + (y + 1)  * n_map_width } else { -1 }
    ]
}

pub fn find_path(n_start_x: i32, n_start_y: i32, n_target_x: i32, n_target_y: i32, p_map: &[u8], n_map_width: i32, n_map_height: i32, mut p_out_buffer: &std::vec::Vec<i32>) -> i32 {
    let start = n_start_y * n_map_width + n_start_x;
    let end = n_target_y * n_map_width + n_target_x;

    let mut found_path = false;

    let mut point_attributes: Vec<PointAttributes> = std::vec::Vec::new();
    point_attributes.reserve_exact((n_map_width * n_map_height) as usize);

    let mut frontier = BinaryHeap::new();
    frontier.push(PointQueueItem { priority: 0, indice: start });

    while let Some(current) = frontier.pop() {
        if current.indice == end {
            found_path = true;
            break;
        }

        let current_cost = point_attributes.get(current.indice as usize).unwrap().cost_sum;

        let neighbors = get_neighbors(current.indice, n_map_width, n_map_height);

        for neighbor in neighbors.iter().filter(|&&n| n != (-1) && *p_map.get(n as usize).unwrap() != 0) {
            let mut neighbor_attr = point_attributes.get_mut(*neighbor as usize).unwrap();
            if neighbor_attr.came_from != (-1) && neighbor_attr.cost_sum <= current_cost + 1 { continue; }

            neighbor_attr.came_from = current.indice;
            neighbor_attr.cost_sum = current_cost + 1;

            let x_cost = neighbor % n_map_width - end % n_map_width;
            let y_cost = neighbor / n_map_width - end / n_map_width;
            let cost = x_cost.abs() + y_cost.abs();
            frontier.push(PointQueueItem { indice: *neighbor, priority: cost + neighbor_attr.cost_sum });
        }
    }

    if !found_path == false { return -1; }
    2
}