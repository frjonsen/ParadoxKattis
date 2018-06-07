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
    indice: u32
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

fn get_neighbors(mut neighbors: &[i32], current_indice: u32, n_map_width: usize, n_map_height: usize) {
    let x = (current_indice % n_map_width as u32) as i32;
    let y = (current_indice / n_map_height as u32) as i32;

    neighbors[0] = if x > 0 { x - 1 + y * n_map_width } else { -1 } as i32;
    neighbors[1] = if x < (n_map_width - 1) { x + 1 + y * n_map_width } else { -1 } as i32;
    neighbors[2] = if y > 0 { x + (y - 1)  * n_map_width } else { -1 } as i32;
    neighbors[3] = if y < (n_map_height - 1) { x + (y + 1)  * n_map_width } else { -1 } as i32;
}

pub fn find_path(n_start_x: u32, n_start_y: u32, n_target_x: u32, n_target_y: u32, p_map: &[u8], n_map_width: usize, n_map_height: usize, mut p_out_buffer: &std::vec::Vec<i32>) -> i32 {
    let start = n_start_y * n_map_width + n_start_x;
    let end = n_target_y * n_map_width + n_target_x;

    let p = PointAttributes { ..Default::default() };
    let found_path = false;

    let mut point_attributes: Vec<PointAttributes> = std::vec::Vec::new();
    point_attributes.reserve_exact((n_map_width * n_map_height) as usize);

    let mut frontier = BinaryHeap::new();
    frontier.push(PointQueueItem { priority: 0, indice: start });

    while let Some(current) = frontier.pop() {
        let current_cost = point_attributes.get(current.indice as usize).unwrap().cost_sum;
        let neighbor_attr = point_attributes.get_mut(0).unwrap();
    }

    2
}